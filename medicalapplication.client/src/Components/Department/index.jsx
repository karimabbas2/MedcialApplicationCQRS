import { useForm, } from "react-hook-form"


const Department = () => {

    const { register, handleSubmit } = useForm();
    const onSubmit = (data) => console.log(data);

    return (
        <>
            <form onSubmit={handleSubmit(onSubmit)} >
                <input type="text" {...register("Department Name :", { required: true, maxLength: 50 })} />
                <input type="text" {...register("Detatils : ")} />
                <button type="submit">Save </button>
            </form>
        </>
    )
}
export default Department
