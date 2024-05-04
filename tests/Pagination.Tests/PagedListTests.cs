using Pagination;
using Pagination.Exceptions;

namespace Libraries.Tests.Features.Pagination
{
    public class PagedListTests
    {
        [Theory]
        [InlineData(0, 3, 1, 2, 3)]
        [InlineData(1, 2, 1, 2, 3)]
        [InlineData(2, 1, 1, 2, 3)]
        public void CreatingPagedList_WithValidData_SetsPropertiesCorrectly(
            int pageIndex,
            int pageSize,
            params int[] data
        )
        {
            // Act
            var pagedList = PagedList<int>.Create(data, pageIndex, pageSize);

            // Assert
            using (new AssertionScope())
            {
                pagedList.PageIndex.Should().Be(pageIndex);
                pagedList.PageSize.Should().Be(pageSize);
                pagedList.TotalCount.Should().Be(data.Length);
                pagedList
                    .Items.Should()
                    .BeEquivalentTo(data.Skip(pageIndex * pageSize).Take(pageSize));
            }
        }

        [Theory]
        [InlineData(0, 3, 2, 1, 3)]
        [InlineData(1, 2, 2, 1, 3)]
        [InlineData(2, 1, 2, 1, 3)]
        public void CreatingOrderedPagedList_WithValidDataAndOrderByAscending_SetsPropertiesCorrectly(
            int pageIndex,
            int pageSize,
            params int[] data
        )
        {
            // Arrange

            var orderBy = new Func<int, int>(x => x);
            var isDescending = false;

            // Act

            var pagedList = PagedList<int>.Create(data, pageIndex, pageSize, orderBy, isDescending);

            // Assert
            using (new AssertionScope())
            {
                pagedList.PageIndex.Should().Be(pageIndex);
                pagedList.PageSize.Should().Be(pageSize);
                pagedList.TotalCount.Should().Be(data.Length);
                pagedList
                    .Items.Should()
                    .BeEquivalentTo(
                        data.Skip(pageIndex * pageSize).Take(pageSize).OrderBy(orderBy)
                    );
            }
        }

        [Theory]
        [InlineData(0, 3, 2, 1, 3)]
        [InlineData(1, 2, 2, 1, 3)]
        [InlineData(2, 1, 2, 1, 3)]
        public void CreatingOrderedPagedList_WithValidDataAndOrderByDescending_SetsPropertiesCorrectly(
            int pageIndex,
            int pageSize,
            params int[] data
        )
        {
            // Arrange

            var orderBy = new Func<int, int>(x => x);
            var isDescending = true;

            // Act

            var pagedList = PagedList<int>.Create(data, pageIndex, pageSize, orderBy, isDescending);

            // Assert
            using (new AssertionScope())
            {
                pagedList.PageIndex.Should().Be(pageIndex);
                pagedList.PageSize.Should().Be(pageSize);
                pagedList.TotalCount.Should().Be(data.Length);
                pagedList
                    .Items.Should()
                    .BeEquivalentTo(
                        data.OrderByDescending(orderBy).Skip(pageIndex * pageSize).Take(pageSize)
                    );
            }
        }

        [Theory]
        [InlineData(0, 3)]
        [InlineData(1, 2)]
        [InlineData(2, 1)]
        public void CreatingOrderedPagedList_WithDateTimeDataAndOrderByAscending_SetsPropertiesCorrectly(
            int pageIndex,
            int pageSize
        )
        {
            // Arrange

            var dateTime = new DateTime(2030, 1, 1);

            var data = new[]
            {
                dateTime,
                new DateTime(dateTime.Ticks + 1),
                new DateTime(dateTime.Ticks + 2)
            };
            var orderBy = new Func<DateTime, DateTime>(x => x.Date);
            var isDescending = false;

            // Act

            var pagedList = PagedList<DateTime>.Create(
                data,
                pageIndex,
                pageSize,
                orderBy,
                isDescending
            );

            // Assert
            using (new AssertionScope())
            {
                pagedList.PageIndex.Should().Be(pageIndex);
                pagedList.PageSize.Should().Be(pageSize);
                pagedList.TotalCount.Should().Be(data.Length);
                pagedList
                    .Items.Should()
                    .BeEquivalentTo(
                        data.Skip(pageIndex * pageSize).Take(pageSize).OrderByDescending(orderBy)
                    );
            }
        }

        [Theory]
        [InlineData(0, 3)]
        [InlineData(1, 2)]
        [InlineData(2, 1)]
        public void CreatingOrderedPagedList_WithDateTimeDataAndOrderByDescending_SetsPropertiesCorrectly(
            int pageIndex,
            int pageSize
        )
        {
            // Arrange

            var dateTime = new DateTime(2030, 1, 1);

            var data = new[]
            {
                dateTime,
                new DateTime(dateTime.Ticks + 1),
                new DateTime(dateTime.Ticks + 2)
            };
            var orderBy = new Func<DateTime, DateTime>(x => x.Date);
            var isDescending = true;

            // Act

            var pagedList = PagedList<DateTime>.Create(
                data,
                pageIndex,
                pageSize,
                orderBy,
                isDescending
            );

            // Assert
            using (new AssertionScope())
            {
                pagedList.PageIndex.Should().Be(pageIndex);
                pagedList.PageSize.Should().Be(pageSize);
                pagedList.TotalCount.Should().Be(data.Length);
                pagedList
                    .Items.Should()
                    .BeEquivalentTo(
                        data.Skip(pageIndex * pageSize).Take(pageSize).OrderByDescending(orderBy)
                    );
            }
        }

        [Theory]
        [InlineData(1, 0, 1, 2, 3)]
        [InlineData(2, 0, 1, 2, 3)]
        [InlineData(3, 0, 1, 2, 3)]
        public void CreatingPagedList_WithPageSizeEqualToZero_CreatesEmptyCollection(
            int pageIndex,
            int pageSize,
            params int[] data
        )
        {
            // Act
            var pagedList = PagedList<int>.Create(data, pageIndex, pageSize);

            // Assert
            using (new AssertionScope())
            {
                pagedList.PageIndex.Should().Be(pageIndex);
                pagedList.PageSize.Should().Be(pageSize);
                pagedList.TotalCount.Should().Be(data.Length);
                pagedList.Items.Should().BeEquivalentTo(Enumerable.Empty<int>());
            }
        }

        [Theory]
        [InlineData(2, 3, 1, 2, 3)]
        [InlineData(3, 2, 1, 2, 3)]
        [InlineData(4, 1, 1, 2, 3)]
        public void CreatingPagedList_WithPageIndexOutOfRange_CreatesEmptyCollection(
            int pageIndex,
            int pageSize,
            params int[] data
        )
        {
            // Act
            var pagedList = PagedList<int>.Create(data, pageIndex, pageSize);

            // Assert
            using (new AssertionScope())
            {
                pagedList.PageIndex.Should().Be(pageIndex);
                pagedList.PageSize.Should().Be(pageSize);
                pagedList.TotalCount.Should().Be(data.Length);
                pagedList.Items.Should().BeEquivalentTo(Enumerable.Empty<int>());
            }
        }

        [Theory]
        [InlineData(-1, -1, 1, 2, 3)]
        [InlineData(-1, 1, 1, 2, 3)]
        [InlineData(1, -1, 1, 2, 3)]
        public void CreatingPagedList_WithInvalidParameters_ThrowsAnException(
            int pageIndex,
            int pageSize,
            params int[] data
        )
        {
            // Arrange

            var createPagedList = () => PagedList<int>.Create(data, pageIndex, pageSize);

            // Assert

            createPagedList.Should().Throw<InvalidPagedRequestDataException>();
        }
    }
}
