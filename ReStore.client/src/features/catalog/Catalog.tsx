import { Avatar, List, ListItem, ListItemAvatar, ListItemText } from "@mui/material";
import { Product } from "../../app/modules/products"

interface Props {
    products: Product[];
}

export default function Catalog({products}: Props) {
    return (
        <>
            <List>
                {products.map((item) => (
                    <ListItem key={item.id}>
                        <ListItemAvatar>
                            <Avatar src={item.pictureUrl} />
                        </ListItemAvatar>
                        <ListItemText>
                            {item.name} - {item.price}
                        </ListItemText>
                    </ListItem>
                ))}
            </List>
        </>
    )
}