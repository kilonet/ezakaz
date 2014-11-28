using System;
using System.Collections.Generic;
using System.Text;

namespace EZakaz.Domain.Dto
{
    public class CategoryDto
    {
        public string Name;
        public int Number;
        public int Id;
        
        public CategoryDto(Category category)
        {
            Name = category.Name;
            Number = category.Number;
            Id = category.Id;
        }

        public CategoryDto()
        {
        }
    }
}
