export function api():string {
  return "http://localhost:5000/api";
}

export function authenticate(){
return `${api()}/v1/a/auth/authenticate`;
}
