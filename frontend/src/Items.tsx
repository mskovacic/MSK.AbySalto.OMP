import {  useEffect, useState } from 'react'
import { createPostsClient } from './client/postsClient';
import { AnonymousAuthenticationProvider, type RequestConfiguration } from "@microsoft/kiota-abstractions";
import { FetchRequestAdapter } from "@microsoft/kiota-http-fetchlibrary";
import type { ProductDTO } from './client/models';
import type { Item_EscapedRequestBuilderPostQueryParameters } from './client/api/basket/item/item_Escaped';

const authProvider = new AnonymousAuthenticationProvider();
const adapter = new FetchRequestAdapter(authProvider);
adapter.baseUrl = "."
const client = createPostsClient(adapter);

function Items() {
    const [items, setItems] = useState<ProductDTO[]>([])
    const [basketId, setBasketId] = useState<string>(localStorage.getItem("basketId") ?? "")

    const fetchItems = async () => {
        const allItems = await client.api.products.get()
        console.log('Fetched items:', allItems)
        if (allItems != null) {
            setItems(allItems)
        }
    }

    const addItemToBasket = async (productId: string, quantity: string) => {
        const body = {
            queryParameters: { productId: productId, quantity: quantity }
        } as RequestConfiguration<Item_EscapedRequestBuilderPostQueryParameters>
        console.log({ body })
        await client.api.basket.byBasketId(basketId).item.post(body)
    }

    const createBasketId = async () => {
        const basket = await client.api.basket.post()
        if (basket == null) {
            return;
        }

        const basketId = String(basket.id?.value)
        setBasketId(basketId)
        localStorage.setItem("basketId", basketId)
    }

    useEffect(() => {
        fetchItems()
    }, [])

    useEffect(() => {
        if (!basketId) {
            createBasketId()
        }
    }, [basketId])

    return (
        <section>
            <div className="card">
                {items.map((product, index) => (
                    <article key={index} className="weather-card">
                        {/*<h3 className="weather-date">*/}
                        {/*    <time dateTime={forecast.date}>{formatDate(forecast.date)}</time>*/}
                        {/*</h3>*/}
                        <p className="weather-summary">{product.name}</p>
                        <div className="weather-temps">
                            <div className="temp-group">
                                <img src={'./images/'+product.image} height='200'  />
                                <span className="temp-unit" aria-hidden="true">{(Number(product.price?.value)/100).toFixed(2)} €</span>
                            </div>
                            <div>
                                <button
                                    className="refresh-button"
                                    onClick={() => { addItemToBasket(String(product.id?.value), 1) }}
                                    type="button"
                                >
                                   
                                    <span>Dodaj u košaricu</span>
                                </button>
                                <button
                                    className="refresh-button"
                                    type="button"
                                >
                                    
                                    <span>Detalji proizvoda</span>
                                </button>
                            </div>
                        </div>
                    </article>
                ))}
            </div>
        </section>
    )
}

export default Items