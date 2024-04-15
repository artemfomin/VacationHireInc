## Cars API

### Endpoints

1. **`/sedans`**

    - **GET** `/sedans`: Returns a list of available Sedan cars
    - Request Format: None
    - Response Format: JSON list of `RentItem<Sedan>`

2. **`/sedans/{id}`**

    - **GET** `/sedans/{id}`: Returns a specific Sedan car with given `{id}`
    - Request Format: None
    - Response Format: Single `RentItem<Sedan>` in JSON format

3. **`/minivans`**

    - **GET** `/minivans`: Returns a list of available Minivan cars
    - Request Format: None
    - Response Format: JSON list of `RentItem<Minivan>`

4. **`/minivans/{id}`**

    - **GET** `/minivans/{id}`: Returns a specific Minivan car with given `{id}`
    - Request Format: None
    - Response Format: Single `RentItem<Minivan>` in JSON format

5. **`/trucks`**

    - **GET** `/trucks`: Returns a list of available Truck cars
    - Request Format: None
    - Response Format: JSON list of `RentItem<Truck>`

6. **`/trucks/{id}`**

    - **GET** `/trucks/{id}`: Returns a specific Truck car with given `{id}`
    - Request Format: None
    - Response Format: Single `RentItem<Truck>` in JSON format

**Note:** Replace `{id}` with an actual `id` in your request.

## Orders API

### Endpoints

1. **`/orders`**

    - **POST** `/orders`: Places a new rent order
    - Request Format: JSON `PlaceRentOrderRequest`
    - Response Format: empty `200` if success.

2. **`/orders`**

    - **PUT** `/orders`: Closes a rent order
    - Request Format: JSON `CloseRentOrderRequest`, with `id` property specifying the order to be closed
    - Response Format: empty `200` if success.

**Note:** Each `RentItem<TModel>` is a JSON object, with `TModel` carrying specific asset properties. For the request/response specifics, please refer to the respective class layouts for `RentItem`, `Sedan`, `Minivan`, `Truck`, `PlaceRentOrderRequest`, `CloseRentOrderRequest` and their properties.