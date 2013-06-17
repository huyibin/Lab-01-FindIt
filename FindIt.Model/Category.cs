//===================================================================================
// $$
//
// Coder: Code Milker v1.0
// 0 - EntityName
// 1 - Properties
//===================================================================================


namespace FindIt.Model {
    using System;

    public class Category {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Notes { get; set; }

        public int SortOrder { get; set; }

        public Guid ParentId { get; set; }


    }
}
