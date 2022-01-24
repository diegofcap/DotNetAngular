using System;
using System.ComponentModel.DataAnnotations;

namespace DotNetAngular.Core
{
    /// <summary>
    /// Represents the base class for entities
    /// </summary>
    public abstract partial class BaseEntity
    {
        /// <summary>
        /// Gets or sets the entity identifier
        /// </summary>
        public int Id { get; set; }

        private DateTime? _createAt;
        public DateTime? CreateAt
        {
            get => _createAt;
            set => _createAt = value ?? DateTime.UtcNow;
        }
        public DateTime? UpdateAt { get; set; }
    }
}