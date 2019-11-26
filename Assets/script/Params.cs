public static class Params 
{
    private static float defSpeed=0.55f;
    private static float carSpeed=0.55f;
    private static bool inMenu=true;
    private static bool carCrashed;
    private static float distanceKm=0;
    private static bool blockMovement;
    private static bool gamePaused=false;
    private static int[] carPrice={0,5000,10000};
    private static int[,] carConfig={{3,4,4},{4,7,9},{7,9,5}};//1-10(min-max) speed handling braking
    public static float CarSpeed { get => carSpeed; set => carSpeed = value; }
    public static float DistanceKm { get => distanceKm; set => distanceKm = value; }
    public static float DefSpeed { get => defSpeed; set => defSpeed = value; }
    public static bool InMenu { get => inMenu; set => inMenu = value; }
    public static bool CarCrashed { get => carCrashed; set => carCrashed = value; }
    public static bool BlockMovement { get => blockMovement; set => blockMovement = value; }
    public static bool GamePaused { get => gamePaused; set => gamePaused = value; }
    public static int[] CarPrice { get => carPrice; set => carPrice = value; }
    public static int[,] CarConfig { get => carConfig; set => carConfig = value; }

    public static float GetSpeed()
    {
        return (int)(carSpeed*3.6f*35);
    }
}
