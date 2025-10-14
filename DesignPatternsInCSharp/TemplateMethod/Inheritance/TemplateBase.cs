namespace DesignPatternsInCSharp.TemplateMethod.Inheritance
{
    public abstract class TemplateBase
    {
#pragma warning disable CS0414 // Field is assigned but never used - keeping for demonstration purposes
        private bool _importantSetting;
#pragma warning restore CS0414
        public void Do()
        {
            BeforeDoing();
            Initialize();
            AfterDone();
        }

        public virtual void BeforeDoing()
        { }

        public abstract void AfterDone();

        private void Initialize()
        {
            _importantSetting = true;
        }
    }

    public class TemplateChild : TemplateBase
    {
        public override void AfterDone()
        {
            // do other stuff
        }
    }
}
