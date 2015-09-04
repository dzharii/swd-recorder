namespace SwdPageRecorder.UI
{
    public interface IPresenter<T>  where T : IView
    {
        void InitWithView(T view);
    }
}
