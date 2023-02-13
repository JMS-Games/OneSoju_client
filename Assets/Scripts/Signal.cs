public static class Sig {
        // client side
    public static readonly int REQUEST_MATCH= 1;
    public static readonly int START_GAME= 2;
    public static readonly int DRAW_CARD= 3;
    public static readonly int USE_CARD= 4;



   // server side
    public static readonly int JOIN_ROOM= 100;
    public static readonly int EXIT_ROOM= 200;
    public static readonly int YOUR_TURN= 300;
    public static readonly int USE_RESULT= 400;
    public static readonly int SOMEONE_WIN= 500;
    public static readonly int END_GAME= 600;
    
}