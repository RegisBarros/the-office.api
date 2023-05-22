﻿using the_office.domain.Common;

namespace the_office.domain.Entities
{
    public class Character : Entity
    {
        /// <summary>
        /// Name of the Character
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Name of the Actor who plays the Character
        /// </summary>
        public string NameActor { get; set; }

        /// <summary>
        /// The status of this character, whether they be living, dead, or unknown
        /// </summary>
        public bool Status { get; set; }

        /// <summary>
        /// The gender of this character, whether they be Female, Male, Genderless, or Unknown
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// A direct image of this character | 300x300
        /// </summary>
        public string ImageUrl { get; set; }

        /// <summary>
        /// this is the character's profession
        /// </summary>
        public string Job { get; set; }

        /// <summary>
        /// The episodes this character stars in
        /// </summary>
        public IEnumerable<EpisodeCharacter> Episodes { get; set; }
    }
}