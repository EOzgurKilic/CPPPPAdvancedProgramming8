namespace CPPPPAdvancedProgramming8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Generic Architecture


            //-Generic Classes
            /*OurGenericClass1<int> obj1 = new OurGenericClass1<int>();
            OurGenericClass2<int, int, int, int> obj2 = new OurGenericClass2<int, int, int, int>();
            Console.WriteLine(obj2.SecondMethod(10,20));*/
            //Check the inheritence behaviours between normal and generic classes below.


            //Generic Methods
            Console.WriteLine(GenericMethod1<int,int>(1,2));
            //So everything seems similar to the generic usage in classes 'til this point but there is a unique ability we have in generic methods' generic parameters:
            //If the method has all its generic type parameters' variables, objects, etc. among its normal parameters,
            //then we don't have to additionally give arguments for the generic parameter part of the method as the compiler automatically assigns them the normal relevant parameters' types.
            Console.WriteLine(GenericMethod1(1, 2)); //T1 and T2 will both be int anyway since 1 (an int) is given for T1 and 2 (another int) for T2.


            //Constraints in Generic Architecture
            //Constraints allows us to specify the types the generic parameters can get.
            //Thus, they prevent unwanted types from being given as arguments which can avoid possible errors.
            //Besides, we can type warning messages for the users which will pop up in the compile time when an unwanted type is given as an argument.
            //In short, it has a significant effect on type safety.
            //Check constraint Arch. syntax below in "ConstraintsClass" class and in "GenericConstraintMethod" method.


            //via  generics, we can overload classes creating multiple classes with the same name under the same namespace as well as methods.
            //This feature is valid for all types that support generic architecture (like structs, interfaces, etc.)
            //Check OverloadedClass below
            /*OverloadedClass<int> obj1 = new OverloadedClass<int>();
            OverloadedClass<int, int> obj2 = new OverloadedClass<int, int>();
            OverloadedClass<int, int, int> obj3 = new OverloadedClass<int, int, int>();*/


            //Down below, there is codeblock which allows you to specify which class and the ones below it in the waterflow as the parameter of the generic.
            //Check NestedClasses
            //NestedClasses<A>.LocalClass<B> obj1 = new NestedClasses<A>.LocalClass<B>(); //Since B is inheriting A, this line fits the criterias of the codeblock.


            //A lil terminological info
            //The usages of generic architectures are called Constructed type terminologically. E.g. list<int> is a constructed type of list<T>.
        }
        static T1 GenericMethod1<T1,T2>(T1 t1, T2 t2) 
        {
            return t1;
        }
    }

    class OurGenericClass1<T> 
    {
        //The 'T' represents the type taken and we can use it creating properties, fields, and etc. with that given type.
        public T FirstProperty { get; set; } //For an instance, if the type is int then this property will be numerical.
        public T FirstMethod(T param1) 
        {
            T sth1 = param1;
            return sth1;
        }

    }
    class OurGenericClass2<T1, T2, T3, T4> //Generic Arch. allows multiple parameter entries.
    {
    
    public T1 FirstProperty { get; set; }
        public T2 FirstMethod(T2 param1)
        {
            T2 sth1 = param1;
            return sth1;
        }
        public T3 SecondMethod(T3 param1,T4 param2)
        {
            return param1;
        }
    }

    //Generic classes can be base classes of normal ones as well as they can inherit normal classes. 
    //Case 1 
    class GenericClass3<t> { }
    class NonGenericClass1 : GenericClass3<int> //It is obligatory to provide particular types as arguments based on the parameters of generic base classes.
    {
    }

    //Case 2 - A generic class inherits a normal one
    //The simple case because the derived generic class has the same behaviour with the other classes inheriting the same base class.

    //Case 3 - The Critical One Generic-Generic Inheritance
    class GenericClass4<t> { }
    class GenericClass5<t> : GenericClass4<int> //In this case, we can give a certain type...
    {
    }
    //... or we can give the parameter of the derived generic class to the base generic class as an argument
    class GenericClass6<t1> : GenericClass4<t1>
    {
    }


    class ConstraintsClass<t1,t2,t3,t4, t5, t6, t7, t8> where t1 : struct /*The parameter will only allow struct type arguments for t1. Called Value Type Constraint*/
        where t2 : class /*Any reference type will be allowed as arguments for t2 (classes, records, abstract classes, interfaces). Called Reference Type Constraint*/ 
        where t3 : new() //Will take only types with instance creation like classes(with public constructors without any parameters because instantiation over these classes must be possible), structs, records, and etc. Moreover, arguments shouldn't be abstract and static classes either. Called New Constraint
        where t4 : ExpBaseClass //Will merely take ExpBaseClass instances of the ones below the relevant class in the waterflow. Called Base Class Constraint.
        where t5 : ExpInterface //Interface Constraint. Only the types of classes, structs, etc. that implemented the specified interface are arguments for t5
        where t6 : Enum //Enum Constraint.
        where t7 : notnull // Types null can't be assigned to.
        where t8 : class, ExpInterface ,new()
    {
        public static void GenericConstraintMethod1<t1>(t1 obj1) where t1 : new() //Because this ensures the argument taken a reference of an object, the compiler will allow us to assign a new object to it.
        {
         obj1 = new t1(); //Check the method bellow to see the error when "where t1 : new()" is not typed.
        }
        /*public static void GenericConstraintMethod2<t1>(t1 obj1)
        {
            obj1 = new t1();
        } */
    }

    class ExpBaseClass
    {
    }

    class ExpDerivedClass : ExpBaseClass
    {
    }

    interface ExpInterface
    {
        
    }


    class OverloadedClass<t1> { public OverloadedClass(){ Console.WriteLine("First Version!"); } }
    class OverloadedClass<t1,t2> { public OverloadedClass() { Console.WriteLine("Second Version!"); } }
    class OverloadedClass<t1,t2,t3> { public OverloadedClass() { Console.WriteLine("Third Version!"); } }


    class NestedClasses<t1>
    {
        public class LocalClass<t2> where t2 : t1 //Now t2 can merely be either the same type as t1 or another type below it in the waterflow.
        {
        }
    }
    class A { }
    class B : A{ }
}
