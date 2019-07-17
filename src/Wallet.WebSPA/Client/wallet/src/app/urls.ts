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

export function createAccount(){
  return `${api()}/v1/ac/account/`;
}
