namespace Web.DTOs
{
    public class PagedResultDto<T>
    {
        public List<T> Items { get; set; } = new();
        public int TotalCount { get; set; }      // Tổng số sản phẩm tìm thấy
        public int PageIndex { get; set; }       // Trang hiện tại (ví dụ: trang 1)
        public int PageSize { get; set; }        // Số sản phẩm mỗi trang (ví dụ: 10 sản phẩm/trang)
        public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize); // Tổng số trang
    }
}
