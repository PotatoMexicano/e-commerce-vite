import { CssBaseline } from "@mui/material";
import { Product } from "../../app/modules/products"
import ProductList from "./ProductList";
import { useEffect, useState } from "react";

export default function Catalog() {

    const [products, setProducts] = useState<Product[]>([]);

    useEffect(() => {
        fetch('http://localhost:5035/api/products')
            .then(response => response.json())
            .then(data => setProducts(data))
    }, []);

    return (
        <>
            <CssBaseline />
            <ProductList products={products} />
        </>
    )
}