using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace App.Views {
    
    [TypeDescriptionProvider(typeof(AbstractCommunicatorProvider))]
    public abstract class BaseFrame : Form {
        protected BaseFrame() {
            
        }
    }
}
