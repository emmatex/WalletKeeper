export interface Transaction {
  id?:string;
  amount:number;
  accountTitle?:string;
  transactionTypeId:number;
  transactionTypeTitle?:string;
  date:Date;
  notes:string;
  transactionCategoryTitle?:string;
  transactionCategoryId:number;
  tags:string[];
  currencyId?:number;
  currencyCode?:string;
  currencyTitle?:string;
}
