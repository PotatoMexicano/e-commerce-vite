import { useEffect, useState } from "react"
import { Basket } from "../../app/modules/basket";
import { Typography } from "@mui/material";
import agent from "../../app/api/agent";
import LoadingComponent from "../../app/layouts/LoadingComponent";

export default function BasketPage() {
    const [loading, setLoading] = useState(true);
    const [basket, setBasket] = useState<Basket | null>(null);

    useEffect(() => {
        agent.Basket.get()
            .then(basket => setBasket(basket))
            .catch(error => console.log(error))
            .finally(() => setLoading(false));
    }, []);

    if (loading) return <LoadingComponent message="Loading basket" />

    if (!basket) return <Typography variant="h3">Your basket is empty</Typography>

    return (
        <h1>buyerId = {basket.buyerId}</h1>
    )
}