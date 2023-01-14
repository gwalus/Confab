using System;
using System.Runtime.Serialization;

namespace Confab.Modules.Speakers.Core.Exceptions
{
    [Serializable]
    internal class SpeakerNotFoundException : Exception
    {
        private Guid _id;

        public SpeakerNotFoundException()
        {
        }

        public SpeakerNotFoundException(Guid id)
        {
            _id = id;
        }

        public SpeakerNotFoundException(string message) : base(message)
        {
        }

        public SpeakerNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected SpeakerNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}