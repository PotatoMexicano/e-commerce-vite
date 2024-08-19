import { CssBaseline } from "@mui/material";
import { Product } from "../../app/modules/products"
import ProductList from "./ProductList";
import { useEffect, useState } from "react";
import agent from "../../app/api/agent";

export default function Catalog() {

    const [products, setProducts] = useState<Product[]>([]);

    useEffect(() => {
        agent.Catalog.list().then(products => setProducts(products))
    }, []);

    return (
        <>
            <CssBaseline />
            <ProductList products={products} />
        </>
    )
}