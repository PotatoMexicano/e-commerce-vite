import { CssBaseline } from "@mui/material";
import { Product } from "../../app/modules/products"
import ProductList from "./ProductList";

interface Props {
    products: Product[];
}

export default function Catalog({products}: Props) {
    return (
        <>
            <CssBaseline />
            <ProductList products={products} />
        </>
    )
}