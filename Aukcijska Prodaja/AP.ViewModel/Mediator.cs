using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP.ViewModel
{
    public class Mediator
    {
        static readonly Mediator instance = new Mediator();//singleton

        public static Mediator Instance
        {
            get
            {
                return instance;
            }
        }

        private Mediator()
        {

        }

        private static Dictionary<string, Action<object>> subscribers = new Dictionary<string, Action<object>>();


        public void Register(string message, Action<object> action)//registrovanje akcija za odredjenu poruku
        {
            subscribers.Add(message, action);
        }


        public void Notify(string message, Object param)// sluzi kako obavestio glavni kad udje u sistem
        {
            foreach (var item in subscribers)
            {

                if (item.Key.Equals(message))
                {
                    Action<object> method = (Action<object>)item.Value;
                    method.Invoke(param);
                }
            }
        }
    }
}
