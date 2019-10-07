
public static class Params 
{
    private static float carSpeed=0.25f;
    public static float CarSpeed { get => carSpeed; set => carSpeed = value; }

    private static float distanceKm=0;
    public static float DistanceKm { get => distanceKm; set => distanceKm = value; }

    public static float GetSpeed()
    {
        return (int)(carSpeed*3.6f*35);
    }
}
