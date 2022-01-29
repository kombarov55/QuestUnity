namespace DefaultNamespace.Common
{
    public static class GlobalState
    {
        public static Observable<string> LifesCountdownObservable = new Observable<string>("00:00");
    }
}