import { z } from "zod";



export const registerSchema = z.object({
    email: z.string().email(),
    password: z.string().regex(/^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$/, {
        message: 'Password must contain 1 lowercase charater, 1 uppercase carachter, 1 number, 1 special and be 6 to 10 characters'
    })
});

export type RegisterSchema = z.infer<typeof registerSchema>;