import { useEffect, useState } from "react"
import { Product } from "../modules/products";

function App() {
  const [products, setProducts] = useState<Product[]>([]);

  useEffect(() => {
    fetch('http://localhost:5035/api/products')
      .then(response => response.json())
      .then(data => setProducts(data))
  }, []);

  function addProducts() {
    setProducts(prevState => [...prevState, { 
      id: prevState.length + 101,
      name: 'product' + (prevState.length + 1), 
      price: (prevState.length * 100) + 100 ,
      brand: 'some brand',
      description: 'some description',
      pictureUrl: 'http://picsum.photos/200'
    }]);
  }

  return (
    <div className="app">
      <h1>Re-Store</h1>
      <ul>
        {products.map(item => (
          <li key={item.id}>{item.name} - {item.price}</li>
        ))}
      </ul>
    </div>
  )
}

export default App
