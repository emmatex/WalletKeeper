export function api():string {
  return "http://localhost:5000/api";
}
export function authenticate(){
return `${api()}/v1/a/auth/authenticate`;
}
export function getAccountTypes(){
return `${api()}/v1/ac/account/getTypes`;
}
export function getAccounts(){
  return `${api()}/v1/ac/account/`;
}
export function getAccount(id:number){
  return `${api()}/v1/ac/account/${id}`;
}
export function createAccount(){
  return `${api()}/v1/ac/account/`;
}
export function editAccount(){
  return `${api()}/v1/ac/account/`;
}
export function getCurrencies(){
  return `${api()}/v1/c/currency/`;
}
export function deleteAccount(id:number){
  return `${api()}/v1/ac/account/${id}`;
}
export function getTransactions(){
  return `${api()}/v1/t/transaction/`;
}
export function getTransaction(id:string){
  return `${api()}/v1/t/transaction/${id}`;
}
export function getCategories(typeId:number){
  return `${api()}/v1/t/transaction/getCategories/${typeId}`;
}
export function createTransaction(){
  return `${api()}/v1/t/transaction/`;
}
export function sumTransactionsByType(){
  return `${api()}/v1/t/transaction/sumByType`;
}
