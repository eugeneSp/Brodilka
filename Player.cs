namespace Game;

public class Player
{
    public double X;
    public double Y;
    public double A;
    public double FOV = Math.PI / 3;

    public Player()
    {
        Y = 0;
        X = 0;
        A = 0;
    }

    public Player(double formalX, double formalY, double formalA)
    {
        X = formalX;
        Y = formalY;
        A = formalA;
    }
}
