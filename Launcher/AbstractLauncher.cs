using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;




namespace Launcher
{

    [TypeDescriptionProvider(typeof(AbstractControlDescriptionProvider<AbstractLauncher, Form>))]
    public abstract class AbstractLauncher : Form
	{
		public Dictionary<string, string> listOfVersions = new Dictionary<string, string>();

		public abstract void UpdateListOfVersions(List<string> Directories);
		protected abstract string GetCommand();

	}


    public class AbstractControlDescriptionProvider<TAbstract, TBase> : TypeDescriptionProvider
    {
        public AbstractControlDescriptionProvider()
            : base(TypeDescriptor.GetProvider(typeof(TAbstract)))
        {
        }

        public override Type GetReflectionType(Type objectType, object instance)
        {
            if (objectType == typeof(TAbstract))
                return typeof(TBase);

            return base.GetReflectionType(objectType, instance);
        }

        public override object CreateInstance(IServiceProvider provider, Type objectType, Type[] argTypes, object[] args)
        {
            if (objectType == typeof(TAbstract))
                objectType = typeof(TBase);

            return base.CreateInstance(provider, objectType, argTypes, args);
        }
    }

    

}
