import {  useEffect, useState } from 'react'
import { createPostsClient } from './client/postsClient';
import { AnonymousAuthenticationProvider } from "@microsoft/kiota-abstractions";
import { FetchRequestAdapter } from "@microsoft/kiota-http-fetchlibrary";
import type { ProductDTO } from './client/models';
import type { Item_EscapedRequestBuilderPostQueryParameters } from './client/api/basket/item/item_Escaped';

const authProvider = new AnonymousAuthenticationProvider();
const adapter = new FetchRequestAdapter(authProvider);
adapter.baseUrl = "."
const client = createPostsClient(adapter);

function Items() {
    const [items, setItems] = useState<ProductDTO[]>([])
    const [basketId, setBasketId] = useState<string>(localStorage.getIem("basketId"))

    const fetchItems = async () => {
        const allItems = await client.api.products.get()
        console.log('Fetched items:', allItems)
        if (allItems != null) {
            setItems(allItems)
        }
    }

    const addItemToBasket = async () => {
        const body = { productId: '1', quantity: '1' } as RequestConfiguration<Item_EscapedRequestBuilderPostQueryParameters>
        await client.api.basket.byBasketId(basketId).item.post(body)
    }

    const createBasketId = async () => {
        const basket = await client.api.basket.post()
        setBasketId('2')
        localStorage.setItem("basketId", "2")
    }

    useEffect(() => {
        fetchItems()
    }, [])

    return (
        <section>
            <div className="card">
                {items.map((forecast, index) => (
                    <article key={index} className="weather-card">
                        {/*<h3 className="weather-date">*/}
                        {/*    <time dateTime={forecast.date}>{formatDate(forecast.date)}</time>*/}
                        {/*</h3>*/}
                        <p className="weather-summary">{forecast.name}</p>
                        <div className="weather-temps">
                            <div className="temp-group">
                                <img src={'./images/'+forecast.image} height='200'  />
                                <span className="temp-unit" aria-hidden="true">{(Number(forecast.price?.value)/100).toFixed(2)} €</span>
                            </div>
                            <div>
                                <button
                                    className="refresh-button"
                                    onClick={fetchWeatherForecast}
                                    type="button"
                                >
                                    <svg
                                        className={`refresh-icon ${loading ? 'spinning' : ''}`}
                                        width="20"
                                        height="20"
                                        viewBox="0 0 24 24"
                                        fill="none"
                                        stroke="currentColor"
                                        strokeWidth="2"
                                        aria-hidden="true"
                                        focusable="false"
                                    >
                                        <path d="M21.5 2v6h-6M2.5 22v-6h6M2 11.5a10 10 0 0 1 18.8-4.3M22 12.5a10 10 0 0 1-18.8 4.2" />
                                    </svg>
                                    <span>{loading ? 'Loading...' : 'Refresh'}</span>
                                </button>
                                <button
                                    className="refresh-button"
                                    onClick={fetchWeatherForecast}
                                    disabled={loading}
                                    aria-label={loading ? 'Loading weather forecast' : 'Refresh weather forecast'}
                                    type="button"
                                >
                                    <svg
                                        className={`refresh-icon ${loading ? 'spinning' : ''}`}
                                        width="20"
                                        height="20"
                                        viewBox="0 0 24 24"
                                        fill="none"
                                        stroke="currentColor"
                                        strokeWidth="2"
                                        aria-hidden="true"
                                        focusable="false"
                                    >
                                        <path d="M21.5 2v6h-6M2.5 22v-6h6M2 11.5a10 10 0 0 1 18.8-4.3M22 12.5a10 10 0 0 1-18.8 4.2" />
                                    </svg>
                                    <span>{loading ? 'Loading...' : 'Refresh'}</span>
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