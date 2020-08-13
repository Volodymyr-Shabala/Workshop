namespace DefaultNamespace
{
    public class ClassWithReferenceToOneIntAndOneInt
    {
        public OneInt oneInt;
        public int x;

        public ClassWithReferenceToOneIntAndOneInt(OneInt oneInt, int x)
        {
            this.oneInt = oneInt;
            this.x = x;
        }
    }
}