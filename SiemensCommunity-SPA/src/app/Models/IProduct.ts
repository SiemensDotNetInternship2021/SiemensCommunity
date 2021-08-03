import { VariableAst } from "@angular/compiler";

export interface IProduct {
    id : number,
    categoryName: string,
    subCategoryName: string,
    user: string,
    categoryId: number,
    subCategoryId: number,
    userId: number,
    name: string,
    isAvailable: boolean,
    imagePath: string,
    rating: number,
    details: string,
}