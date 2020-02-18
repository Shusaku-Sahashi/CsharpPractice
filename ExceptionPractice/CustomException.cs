using System;
using System.Runtime.Serialization;

namespace ExceptionPractice
{
    [Serializable]
    public class CustomException : Exception 
    {
        public string ObjectGraph { get; private set; }

        public CustomException(string message, string objectGraph) : base(message)
        {
            this.ObjectGraph = objectGraph;
        }

        protected CustomException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            this.ObjectGraph = info.GetString("ObjectGraph");
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("ObjectGraph", ObjectGraph);
        }
    }
}