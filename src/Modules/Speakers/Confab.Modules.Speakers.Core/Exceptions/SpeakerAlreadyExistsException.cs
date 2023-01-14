using System;
using System.Runtime.Serialization;

namespace Confab.Modules.Speakers.Core.Exceptions
{
    [Serializable]
    internal class SpeakerAlreadyExistsException : Exception
    {
        private Guid _id;

        public SpeakerAlreadyExistsException()
        {
        }

        public SpeakerAlreadyExistsException(Guid id)
        {
            _id = id;
        }

        public SpeakerAlreadyExistsException(string message) : base(message)
        {
        }

        public SpeakerAlreadyExistsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected SpeakerAlreadyExistsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}