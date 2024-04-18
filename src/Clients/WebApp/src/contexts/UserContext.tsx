import { createContext, useContext, useState } from "react";
import { UserModel } from "../models/UserModel";

export interface Product {
  id: number;
  name: string;
  price: number;
}

export interface CartItem {
  product: Product;
  quantity: number;
}

export type Cart = CartItem[];

interface UserContextType {
  user: UserModel | null;
  setUserInfo: (user: UserModel) => void;

  cart: Cart;
  addToCart: (product: Product, quantity: number) => void;
  removeFromCart: (productId: number) => void;
  clearCart: () => void;
}

const UserContext = createContext<UserContextType | null>(null);

export const UserProvider = ({ children }: { children: React.ReactNode }) => {
  const [cart, setCart] = useState<Cart>([]);
  const [user, setUser] = useState<UserModel>(() => {
    const userJSON = localStorage.getItem("user");

    if (userJSON !== null) {
      const userData = JSON.parse(userJSON);

      return new UserModel(userData.userName, userData.token);
    }

    return new UserModel("", "");
  });

  const setUserInfo = (user: UserModel) => {
    setUser(user);
  };

  const addToCart = (product: Product, quantity: number) => {
    const newItem: CartItem = { product, quantity };
    setCart([...cart, newItem]);
  };

  const removeFromCart = (productId: number) => {
    const updatedCart = cart.filter((item) => item.product.id !== productId);
    setCart(updatedCart);
  };

  const clearCart = () => {
    setCart([]);
  };

  const value = {
    user,
    setUserInfo,

    addToCart,
    removeFromCart,
    clearCart,
    cart,
  };

  return <UserContext.Provider value={value}>{children}</UserContext.Provider>;
};

export const useUser = () => {
  const context = useContext(UserContext);

  if (!context) {
    throw new Error("useUser must be used within a UserProvider");
  }

  return context;
};
