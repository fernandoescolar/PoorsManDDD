using System;
using System.ComponentModel.DataAnnotations;
using PoorsManDDD.Domain.Entities;

namespace PoorsManDDD.Data.Entities
{
    internal class TodoItem : ITodoItem
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        [Required]
        public DateTime DateCreation { get; set; }

        public DateTime LastModificationDate { get; set; }

        [Required]
        public TodoState State { get; set; }
    }
}
