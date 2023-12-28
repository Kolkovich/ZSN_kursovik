class user_model{
    
    public constructor(public phone_number : string,
                       public password: string) {}
}

async function get_user() : Promise<user_model>{
    
        const response = await fetch('user');
        const data = await response.json();
        return new user_model(data.phone_number, data.password);
}