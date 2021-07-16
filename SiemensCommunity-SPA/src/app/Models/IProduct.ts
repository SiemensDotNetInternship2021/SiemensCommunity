export interface IProduct {
    id : number,
    categoryId: number,
    subCategoryId: number,
    user: number,
    name: string,
    isAvailable: boolean,
    imagePath: string,
    details: string,
}