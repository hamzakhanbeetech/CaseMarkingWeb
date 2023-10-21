import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ApiService } from 'src/app/api.service';

@Component({
  selector: 'app-categories',
  templateUrl: './categories.component.html',
  styleUrls: ['./categories.component.css']
})
export class CategoriesComponent implements OnInit {

  categoryForm! : FormGroup

  categories: any[] = [];

  editingCategory! : any
  
  constructor( private fb: FormBuilder, private apiService: ApiService) {

    this.categoryForm = this.fb.group({
      categoryName: ['', [Validators.required]],
    });
  }

  ngOnInit(): void {
    this.loadCategories();
  }

  loadCategories() {
    this.apiService.getCategories().subscribe((data:any) => {
      this.categories = data;
    });
  }

  saveCategory() {
    if (this.categoryForm.valid) {
      const newCategory: any = this.categoryForm.value as any;

      this.apiService.createCategory(newCategory).subscribe(() => {
        alert("Successfully Added New Category")
        this.categoryForm.reset();
        this.loadCategories();
      }, (err:any) => {        
        alert("Error Whil Added New Category")
      });
    }
  }
  editCategory(Category: any) {
    // Implement the logic to open an edit form or dialog.
    // For this example, let's assume you have a variable to track the edited Category.
    this.editingCategory = { ...Category };
  }
  
  saveEditedCategory() {
    // Make an HTTP request to update the Category.
    if(this.editingCategory == null){
      return
    }
    this.apiService.updateCategory(this.editingCategory.CategoryID, this.editingCategory).subscribe(() => {
      // Category updated successfully; reload the Category list.
      this.loadCategories();
      // Reset the editingCategory variable or close the edit form/dialog.
      this.editingCategory = null;
    });
  }

  deleteCategory(category: any) {
    
    this.apiService.deleteCategory(category.caseCategoryId).subscribe(() => {
      // Category deleted successfully; reload the Category list
      this.loadCategories();
    });
  }

}
