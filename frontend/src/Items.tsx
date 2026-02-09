import {  useEffect } from 'react'
import { createPostsClient } from './client/postsClient';
import { AnonymousAuthenticationProvider } from "@microsoft/kiota-abstractions";
import { FetchRequestAdapter } from "@microsoft/kiota-http-fetchlibrary";

const authProvider = new AnonymousAuthenticationProvider();
const adapter = new FetchRequestAdapter(authProvider);
adapter.baseUrl = "."
const client = createPostsClient(adapter);



function Items() {
    //const [items, setItems] = useState<WeatherForecast[]>([])

    const fetchItems = async () => {
        const allItems = await client.api.products.get()
        console.log('Fetched items:', allItems)
        //setItems(allItems.value)
    }

    useEffect(() => {
        fetchItems()
    }, [])

    return (
        <section>
        </section>
    )
}

export default Items