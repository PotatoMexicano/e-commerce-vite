import { useEffect, useState } from "react"
import { Product } from "../modules/products";
import Catalog from "../../features/catalog/Catalog";
import Header from "./Headers";
import { Container } from "@mui/material";

function App() {
  const [products, setProducts] = useState<Product[]>([]);

  useEffect(() => {
    fetch('http://localhost:5035/api/products')
      .then(response => response.json())
      .then(data => setProducts(data))
  }, []);

  return (
    <div className="app">
      <Header />
      <Container>
        <Catalog products={products} />      
      </Container>
    </div>
  )
}

export default App
