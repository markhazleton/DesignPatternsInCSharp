namespace DesignPatternsInCSharp.TemplateMethod.Inheritance
{
    public abstract class Base
    {
#pragma warning disable CS0414 // Field is assigned but never used - keeping for demonstration purposes
        private bool _importantSetting;
#pragma warning restore CS0414
        public virtual void Do()
        {
            Initialize();
        }

        private void Initialize()
        {
            _importantSetting = true;
        }
    }

    public class Child : Base
    {
        public override void Do()
        {
            // do other stuff
        }
    }
}
