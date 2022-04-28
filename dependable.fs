type Dependable<'T>(_value: 'T, condition: 'T -> bool) =
    let mutable _value = _value

    do
        match condition(_value) with
        | true -> ()
        | false -> failwith "DependableConditionError"
    
    member self.value
        with get() = _value 
        and set(x) = 
            match condition(x) with
            | true ->
                _value <- x
            | false -> 
                failwith "DependableConditionError"

type PositiveNumber(_value: int) = 
    inherit Dependable<int>(_value, fun x -> x >= 0)

let a = PositiveNumber(50) // it works
a.value <- -27 // causes an error
