using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Classes
{
    public class Feedback
    {
        /// <summary>
        /// The database id of the rating
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The feedback rating
        /// </summary>
        public Rating Rating { get; set; }

        /// <summary>
        /// The point in time when the feedback was received
        /// </summary>
        public DateTime InstantUtc { get; set; }

        /// <summary>
        /// The host the feedback comes from
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// The name of the user providing the feedback
        /// </summary>
        public string User { get; set; }

        /// <summary>
        /// The text describing the feedback
        /// </summary>
        public string FeedbackText { get; set; }

        /// <summary>
        /// The contacts the user possibly wants to be contacted at
        /// </summary>
        public string UserContacts { get; set; }
    }
}