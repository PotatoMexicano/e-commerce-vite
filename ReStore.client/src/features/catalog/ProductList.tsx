import { List } from "@mui/material";
import { Product } from "../../app/modules/products";
import ProductCard from "./ProductCard";

interface Props {
    products: Product[];
}

export default function ProductList({ products }: Props) {
    return (
        <List>
            {products.map((item) => (
                <ProductCard product={item}/>
            ))}
        </List>
    )
}