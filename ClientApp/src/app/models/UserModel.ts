export interface UserModel{
  id?: number,
  email: string,
  password: string, //TODO Change password from plain string to some form of hashed value
  isAdmin: boolean
}
