import { Grid } from "@mui/material";
import { Product } from "../../app/modules/products";
import ProductCard from "./ProductCard";

interface Props {
    products: Product[];
}

export default function ProductList({ products }: Props) {
    return (
        <Grid container spacing={4}>
            {products.map((item) => (
                <Grid item xs={4} key={item.id}>
                    <ProductCard product={item} />
                </Grid>
            ))}
        </Grid>
    )
}