import { useState } from "react";
import Button from "@mui/material/Button";

interface Product {
  id: number;
  name: string;
  price: number;
}

interface IProps {
  products: Product[];
}

export default function ProductList(props: IProps) {
  return (
    <>
      <h3>Product List</h3>

      <ul>
        {props.products.map((product) => (
          <li key={product.id}>
            <h3>{product.name}</h3>
            <p>${product.price}</p>
          </li>
        ))}
      </ul>
    </>
  );
}
