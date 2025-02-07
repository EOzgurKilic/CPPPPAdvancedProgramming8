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
            //So everything seems similar to the generic usage in classes 'til this point but there is a unique ability we have in generic method's generic parameters:
            //If the method has all its generic type parameters' variables, objects, etc. among its normal parameters,
            //then we don't have to additionally give arguments for the generic parameter part of the method as the compiler automatically assigns them the normal relevant parameters' types.
            Console.WriteLine(GenericMethod1(1, 2)); //T1 and T2 will both be int anyway since 1 (an int) is given for T1 and 2 (another int) for T2.
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
}
