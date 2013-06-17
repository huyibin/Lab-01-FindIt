//===================================================================================
// Category's Contract
//
// Coder: Code Milker v1.0
// 0 - EntityName
// 1 - Properties
//===================================================================================

namespace FindIt.Domain.Contracts {  
     using System;

    public interface ICreateCategoryCommand {
	Guid Id {get;set;}

string Name {get;set;}

string Notes {get;set;}

int SortOrder {get;set;}

Guid ParentId {get;set;}

    
    }
}
