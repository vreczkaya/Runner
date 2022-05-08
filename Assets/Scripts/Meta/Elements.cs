public static class Elements 
{
    public static int blackElementAmount;
    public static int blueElementAmount;
    public static int yellowElementAmount;
    public static int greenElementAmount;
    public static int whiteElementAmount;

    public static void AddElement(int element, int sum)
    {
        element += sum;
    }

    public static void SubstractElement(int element, int sum)
    {
        element -= sum;
    }
}
