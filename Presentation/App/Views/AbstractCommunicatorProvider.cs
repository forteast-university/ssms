using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace App.Views {
    public class AbstractCommunicatorProvider : TypeDescriptionProvider {
        public AbstractCommunicatorProvider()
            : base(TypeDescriptor.GetProvider(typeof(UserControl))) {
        }
        public override Type GetReflectionType(Type objectType, object instance) {
            return typeof(UserControl);
        }
        public override object CreateInstance(IServiceProvider provider, Type objectType, Type[] argTypes, object[] args) {
            objectType = typeof(UserControl);
            return base.CreateInstance(provider, objectType, argTypes, args);
        }
    }
}
