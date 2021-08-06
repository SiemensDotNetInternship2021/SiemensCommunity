import { IDetail } from "./IDetail";

export interface IBorrowedProducts {
    userId: number,
    productId: number,
    startDate: string,
    endDate: string,
    
    id : number,
    categoryName: string,
    subCategoryName: string,
    user: string,
    name: string,
    isAvailable: boolean,
    imagePath: string,
    rating: number,
    details: string,
    detailsList: IDetail[]
}