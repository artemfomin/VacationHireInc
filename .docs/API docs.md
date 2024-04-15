## Cars API

### Endpoints

1. `cars/sedans` **GET** - Returns a list of available Sedan cars
    - Request Format: None
    - Response Format: JSON list of `RentItem<Sedan>`
      <br/><br/>
2. `cars/sedans/{id}` **GET** - Returns a specific Sedan car with given `{id}`
    - Request Format: None
    - Response Format: Single `RentItem<Sedan>` in JSON format
      <br/><br/>
3. `cars/minivans` **GET** - Returns a list of available Minivan cars
    - Request Format: None
    - Response Format: JSON list of `RentItem<Minivan>`
      <br/><br/>
4. `cars/minivans/{id}` **GET** - Returns a specific Minivan car with given `{id}`
    - Request Format: None
    - Response Format: Single `RentItem<Minivan>` in JSON format
      <br/><br/>
5. `cars/trucks` **GET** - Returns a list of available Truck cars
    - Request Format: None
    - Response Format: JSON list of `RentItem<Truck>`
      <br/><br/>
6. `cars/trucks/{id}` **GET** - Returns a specific Truck car with given `{id}`
    - Request Format: None
    - Response Format: Single `RentItem<Truck>` in JSON format
      <br/><br/>
7. `cars/sedans` **POST** - Creates a new Sedan car
   - Request Format: JSON `RentItem<Sedan>`
   - Response Format: Depends on implementation specifics, possibly a confirmation message or created Sedan ID.
     <br/><br/>
8. `cars/minivans` **POST** - Creates a new Minivan car
   - Request Format: JSON `RentItem<Minivan>`
   - Response Format: Depends on implementation specifics, possibly a confirmation message or created Minivan ID.
     <br/><br/>
9. `cars/trucks` **POST** - Creates a new Truck car
   - Request Format: JSON `RentItem<Truck>`
   - Response Format: Depends on implementation specifics, possibly a confirmation message or created Truck ID.
     <br/><br/>
**Note:** Replace `{id}` with an actual `id` in your request.

## Orders API

### Endpoints

1. `/orders` **POST** - Places a new rent order
    - Request Format: JSON `PlaceRentOrderRequest`
    - Response Format: empty `200` if success.
      <br/><br/>
2. `/orders` **PUT** - Closes a rent order
    - Request Format: JSON `CloseRentOrderRequest`, with `id` property specifying the order to be closed
    - Response Format: empty `200` if success.
      <br/><br/>
**Note:** Each `RentItem<TModel>` is a JSON object, with `TModel` carrying specific asset properties. For the request/response specifics, please refer to the respective class layouts for `RentItem`, `Sedan`, `Minivan`, `Truck`, `PlaceRentOrderRequest`, `CloseRentOrderRequest` and their properties.

## Invoice API

### Endpoints

1. `/invoices` **GET** - Retrieves all invoices
   - Request Format: None
   - Response Format: JSON array of `Invoice` objects, `200` if success.
     <br/><br/>
2. `/invoices/{id}` **GET** - Retrieves a specific invoice by its `id`
   - Request Format: URL parameter `id` as `Guid`
   - Response Format: JSON `Invoice` object, `200` if success.
     <br/><br/>
3. `/invoices` **POST** - Creates a new invoice
   - Request Format: JSON `Invoice`
   - Response Format: `200` if success, newly created `Invoice` object in case of success.
     <br/><br/>

**Note:** `Invoice` is a JSON object with specific invoice properties. For the request/response specifics, please refer to the respective class layout for `Invoice` and its properties.